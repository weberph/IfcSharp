#pragma once

#include "GetStringView.hxx"

#include <ifc/index-utils.hxx>
#include <ifc/reader.hxx>

#include <functional>
#include <optional>
#include <stdexcept>
#include <type_traits>

#include <gsl/span>

namespace ifchelper
{
    namespace detail
    {
        template<class T, class U>
        using Ptm = T U::*;

        template<class TSort>
        void sameSortOrThrow( const TSort a, const TSort b )
        {
            assert( a == b );
            if ( a != b )
            {
                throw std::runtime_error( "invalid sort" );
            }
        }
    }

    template<index_like::MultiSorted TIndex>
    struct Query;

    template<class TIndex, class UIndex>
    struct EitherQuery
    {
        const ifc::Reader& reader;
        const TIndex index1{};
        const UIndex index2{};
        const bool first{};

        template<class F>
        auto visit( F&& f ) const
        {
            if ( first )
            {
                if constexpr ( std::invocable<F, decltype( reader ), decltype( index1 )> )
                {
                    return f( reader, index1 );
                }
                else
                {
                    return f( index1 );
                }
            }
            else
            {
                if constexpr ( std::invocable<F, decltype( reader ), decltype( index2 )> )
                {
                    return f( reader, index2 );
                }
                else
                {
                    return f( index2 );
                }
            }
        }
    };

    template<class T>
    struct QuerySequence
    {
        const ifc::Reader& reader;
        const gsl::span<const T> span{};

        const Query<T> operator[]( size_t index ) const
        {
            return Query( reader, span[index] );
        }
    };

    template<index_like::MultiSorted TIndex>
    struct OptionalQuery
    {
        const ifc::Reader& reader;
        const TIndex index{};

        operator bool() const
        {
            return not index_like::null( index );
        }

        Query<TIndex> value() const
        {
            if ( not *this )
            {
                throw std::runtime_error( "bad optional query access" );
            }

            return { reader, index };
        }

        template<index_like::Fiber U, index_like::MultiSorted UIndex>
        OptionalQuery<UIndex> tryGet( detail::Ptm<UIndex, U> ptm ) const
        {
            if ( index.sort() == U::algebra_sort )
            {
                const auto& ref = reader.get<U>( index );
                return { reader, ref.*ptm };
            }

            return { reader, UIndex{} };
        }

        template<index_like::Fiber U, index_like::MultiSorted UIndex>
        OptionalQuery<UIndex> get( detail::Ptm<UIndex, U> ptm ) const
        {
            if ( *this )
            {
                detail::sameSortOrThrow( index.sort(), U::algebra_sort );
                const auto& ref = reader.get<U>( index );
                return { reader, ref.*ptm };
            }

            return { reader, UIndex{} };
        }

        template<index_like::Fiber U>
        std::optional<std::reference_wrapper<const U>> get() const
        {
            if ( *this )
            {
                detail::sameSortOrThrow( index.sort(), U::algebra_sort );
                return reader.get<U>( index );
            }

            return {};
        }

        template<index_like::Fiber U>
        std::optional<std::reference_wrapper<const U>> tryGet() const
        {
            if ( *this && index.sort() == U::algebra_sort )
            {
                return reader.get<U>( index );
            }

            return {};
        }

        template<std::invocable<decltype( reader ), decltype( index )> F>
        auto visit( F&& f ) -> std::optional<std::invoke_result_t<F, decltype( reader ), decltype( index )>> const
        {
            if ( *this )
            {
                return f( reader, index );
            }

            return {};
        }
    };

    template<index_like::MultiSorted TIndex, index_like::Fiber U>
    struct QueryResult;

    template<index_like::Fiber U>
    struct OptionalResult : std::optional<std::reference_wrapper<const U>>
    {
        const U& value() const noexcept
        {
            return std::optional<std::reference_wrapper<const U>>::value().get();
        }
    };

    template<index_like::MultiSorted TIndex>
    struct Query
    {
        const ifc::Reader& reader;
        const TIndex index{};

        template<index_like::Fiber U, index_like::MultiSorted UIndex>
        Query<UIndex> get( detail::Ptm<UIndex, U> ptm ) const
        {
            detail::sameSortOrThrow( index.sort(), U::algebra_sort );
            const auto& ref = reader.get<U>( index );
            return { reader, ref.*ptm };
        }

        template<index_like::Fiber U>
        const U& get() const
        {
            detail::sameSortOrThrow( index.sort(), U::algebra_sort );
            return reader.get<U>( index );
        }

        template<index_like::Fiber U, index_like::MultiSorted UIndex>
        std::tuple<Query<UIndex>, const U&> getWithQuery( detail::Ptm<UIndex, U> ptm ) const
        {
            detail::sameSortOrThrow( index.sort(), U::algebra_sort );
            const auto& ref = reader.get<U>( index );
            return { { reader, ref.*ptm }, ref };
        }

        template<index_like::Fiber U>
        QueryResult<TIndex, U> map() const
        {
            detail::sameSortOrThrow( index.sort(), U::algebra_sort );
            return { reader, index, reader.get<U>( index ) };
        }

        template<index_like::Fiber U>
        std::tuple<TIndex, const U&> getWithIndex() const
        {
            detail::sameSortOrThrow( index.sort(), U::algebra_sort );
            return { index, reader.get<U>( index ) };
        }

        template<index_like::Fiber U, index_like::MultiSorted UIndex>
        OptionalQuery<UIndex> tryGet( detail::Ptm<UIndex, U> ptm ) const
        {
            if ( index.sort() == U::algebra_sort )
            {
                const auto& ref = reader.get<U>( index );
                return { reader, ref.*ptm };
            }

            return { reader, UIndex{} };
        }

        template<index_like::Fiber U, class UOther>
        std::optional<UOther> tryGet( detail::Ptm<UOther, U> ptm ) const
        {
            if ( index.sort() == U::algebra_sort )
            {
                const auto& ref = reader.get<U>( index );
                return { ref.*ptm };
            }

            return {};
        }

        template<index_like::Fiber U>
        OptionalResult<U> tryGet() const
        {
            if ( index.sort() == U::algebra_sort )
            {
                return { reader.get<U>( index ) };
            }

            return {};
        }

        template<class U>
        auto sequence() const
        {
            detail::sameSortOrThrow( index.sort(), U::algebra_sort );
            return QuerySequence{ reader, reader.sequence( reader.get<U>( index ) ) };
        }

        template<index_like::Fiber U>
        std::string_view identity( detail::Ptm<ifc::symbolic::Identity<ifc::TextOffset>, U> ptm ) const
        {
            detail::sameSortOrThrow( index.sort(), U::algebra_sort );
            const auto& ref = reader.get<U>( index );
            return reader.get( ( ref.*ptm ).name ); // TODO check index for null (also other places)
        }

        template<index_like::Fiber U>
        std::string_view identity( detail::Ptm<ifc::symbolic::Identity<ifc::NameIndex>, U> ptm ) const
        {
            detail::sameSortOrThrow( index.sort(), U::algebra_sort );
            const auto& ref = reader.get<U>( index );
            return getStringView( reader, ref.*ptm ); // TODO check index for null (also other places)
        }

        template<class F>
        auto visit( F&& f ) const
        {
            if constexpr ( std::invocable<F, decltype( reader ), decltype( index )> )
            {
                return f( reader, index );
            }
            else
            {
                return f( index );
            }
        }

        template<index_like::Fiber U1, index_like::Fiber U2, class T1, class T2>
        EitherQuery<T1, T2> either( detail::Ptm<T1, U1> ptm1, detail::Ptm<T2, U2> ptm2 ) const
        {
            if ( index.sort() == U1::algebra_sort )
            {
                const auto& ref = reader.get<U1>( index );
                return { reader, ref.*ptm1, {}, true };
            }
            else
            {
                assert( index.sort() == U2::algebra_sort );
                const auto& ref = reader.get<U2>( index );
                return { reader, {}, ref.*ptm2, false };
            }
        }
    };

    template<index_like::MultiSorted TIndex, index_like::Fiber U>
    struct QueryResult : public Query<TIndex>
    {
        std::reference_wrapper<const U> result;

        const U& value() const noexcept
        {
            return result;
        }

        operator const U& ( ) const noexcept
        {
            return result;
        }

        const U* operator->() const noexcept
        {
            return &result.get();
        }
    };
}
