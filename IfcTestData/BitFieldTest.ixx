#pragma once

#pragma warning( disable : 5244 ) // '#include <...>' in the purview of module '...' appears erroneous.

#include <cstdint>
#include <cstddef>

namespace bitfieldtest
{
    struct BitFieldStruct1
    {
        uint8_t field1 : 4;
        uint8_t field2 : 4;

        uint8_t field3 : 4;
        uint8_t field4 : 4;
    };

    struct BitFieldStruct2
    {
        uint32_t field1 : 8;
        uint32_t field2 : 8;
        uint32_t field3 : 8;
        uint32_t field4 : 8;

        uint32_t field5 : 8;
        uint32_t field6 : 8;
        uint32_t field7 : 8;
        uint32_t field8 : 8;
    };

    struct BitFieldStruct3
    {
        uint8_t field1 : 4;
        uint32_t field2 : 14; // 18
        uint16_t field3 : 12; // 30
        uint8_t field4 : 3; // 33
    };

    struct BitFieldStruct4
    {
        uint32_t field1 : 1;
        uint8_t field2 : 1;
    };

    struct BitFieldStruct5
    {
        uint8_t field1 : 1;

        void method()
        {
            throw "method declarations between bitfields don't affect merging";
        }

        uint8_t field2 : 1;
    };

    struct BitFieldStruct6
    {
        uint8_t field1 : 7;
        uint8_t field2 : 7;
        uint8_t field3 : 7;
        uint8_t field4 : 7;
        uint8_t field5 : 7;
        uint8_t field6 : 7;
        uint8_t field7 : 7;
    };

    constexpr inline size_t BitFieldStruct1Size = sizeof( BitFieldStruct1 );
    constexpr inline size_t BitFieldStruct2Size = sizeof( BitFieldStruct2 );
    constexpr inline size_t BitFieldStruct3Size = sizeof( BitFieldStruct3 );
    constexpr inline size_t BitFieldStruct4Size = sizeof( BitFieldStruct4 );
    constexpr inline size_t BitFieldStruct5Size = sizeof( BitFieldStruct5 );
    constexpr inline size_t BitFieldStruct6Size = sizeof( BitFieldStruct6 );

    static_assert( BitFieldStruct1Size == 2 );
    static_assert( BitFieldStruct2Size == 8 );
    static_assert( BitFieldStruct3Size == 12 );
    static_assert( BitFieldStruct4Size == 8 );
    static_assert( BitFieldStruct5Size == 1 );
    static_assert( BitFieldStruct6Size == 7 ); // no optimal packing if bits don't fit
}
