module;

#include "NonModuleHeaderWithEnum.hxx"

export module ExportedEnums;

export {
    struct TestStruct
    {
        int a;
        double b;
    };

    test::inner::MyEnum MyEnumExported;
}
