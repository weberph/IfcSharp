#include "NonModuleHeaderWithEnum.hxx"
#include "Manual_MyEnumString.hxx"

#include <concepts>
#include <string>
#include <iostream>

using test::inner::MyEnum;

int main()
{
    std::cout << "MyEnum:    " << to_string<MyEnum>( MyEnum::Value1 ) << std::endl;
    std::cout << "MyEnum:    " << enum_to_string<MyEnum>{}( MyEnum::Value1 ) << std::endl;

    //std::cout << "OtherEnum: " << to_string<test::OtherEnum>( test::OtherEnum::Other1 ) << std::endl;
}

static_assert( to_string<MyEnum>( MyEnum::Value1 ) == "Value1" );