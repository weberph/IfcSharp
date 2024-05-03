#pragma once

#include <string_view>

template<class T>
struct enum_to_string
{
    constexpr std::string_view operator()( T val ) const noexcept;
};

template<class T>
inline constexpr auto to_string = enum_to_string<T>{};
