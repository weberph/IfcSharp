#pragma once

#include <ifc/index-utils.hxx>
#include <ifc/reader.hxx>

#include <stdexcept>
#include <string_view>

namespace ifchelper
{
    struct GetStringViewFunctor
    {
        std::string_view operator()( const ifc::Reader& reader, const ifc::TextOffset textOffset ) const
        {
            if ( textOffset == ifc::TextOffset{} )
            {
                return "";
            }

            return reader.get( textOffset );
        }

        std::string_view operator()( const ifc::Reader& reader, const ifc::NameIndex index ) const
        {
            if ( index_like::null( index ) )
            {
                return "";
            }

            switch ( index.sort() )
            {
                case ifc::NameSort::Identifier: return ( *this )( reader, ifc::TextOffset( index.index() ) );
                case ifc::NameSort::Operator: return ( *this )( reader, reader.get<ifc::symbolic::OperatorFunctionId>( index ).name );
                case ifc::NameSort::Conversion: return ( *this )( reader, reader.get<ifc::symbolic::ConversionFunctionId>( index ).name );
                case ifc::NameSort::Literal: return ( *this )( reader, reader.get<ifc::symbolic::LiteralOperatorId>( index ).name_index );
                case ifc::NameSort::Template: return ( *this )( reader, reader.get<ifc::symbolic::TemplateName>( index ).name );
                    // case ifc::NameSort::Specialization: return ( *this )( reader, reader.get<ifc::symbolic::SpecializationName>( index ).? );
                case ifc::NameSort::SourceFile: return ( *this )( reader, reader.get<ifc::symbolic::SourceFileName>( index ).name );
                    // case ifc::NameSort::Guide: return ( *this )( reader, reader.get<ifc::symbolic::GuideName>( index ).? );
            }

            throw std::runtime_error( "getStringView: unexpected name index" );
        }

        std::string_view operator()( const ifc::Reader& reader, const ifc::symbolic::Identity<ifc::NameIndex> nameIndexId ) const
        {
            return ( *this )( reader, nameIndexId.name );
        }

        std::string_view operator()( const ifc::Reader& reader, const ifc::symbolic::Identity<ifc::TextOffset> textOffsetId ) const
        {
            return ( *this )( reader, textOffsetId.name );
        }
    };

    constexpr inline GetStringViewFunctor getStringView = GetStringViewFunctor{};
}
