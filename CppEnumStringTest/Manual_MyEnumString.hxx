#pragma once

#include "NonModuleHeaderWithEnum.hxx"
#include "CppEnumString.hxx"

using test::inner::MyEnum;

template<>
struct enum_to_string<MyEnum>
{
    constexpr std::string_view operator()( MyEnum val ) const noexcept
    {
        switch ( val )
        {
            case MyEnum::Value1: return "Value1";
            case MyEnum::Value2: return "Value2";
            case MyEnum::Value3: return "Value3";
            default: return "<Unknown>";
        }
    }
};
