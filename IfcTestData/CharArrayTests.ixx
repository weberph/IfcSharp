export module CharArrayTests;

import <string_view>;

using namespace std::literals::string_view_literals;

static_assert( "ü"sv == "\xC3\xBC"sv ); // ensure source file is utf-8

export
{
    constexpr const char LiteralWithUmlauts[] = "äöü";
    constexpr const char8_t U8LiteralWithUmlauts[] = u8"äöü";
    constexpr const char16_t U16LiteralWithUmlauts[] = u"äöü";
    constexpr const char32_t U32LiteralWithUmlauts[] = U"äöü";
    constexpr const wchar_t WideLiteralWithUmlauts[] = L"äöü";

    static_assert( sizeof( LiteralWithUmlauts ) == 7 );
    static_assert( sizeof( U8LiteralWithUmlauts ) == 13 );   // W - 7 on gcc 14.1 and clang 18.1.0
    static_assert( sizeof( U16LiteralWithUmlauts ) == 14 );  // H - 8 on gcc 14.1 and clang 18.1.0
    static_assert( sizeof( U32LiteralWithUmlauts ) == 28 );  // Y - 16 on gcc 14.1 and clang 18.1.0
    static_assert( sizeof( WideLiteralWithUmlauts ) == 14 ); // ? - 16 on gcc 14.1 and clang 18.1.0 (wchar_t is 4 bytes)

    // https://godbolt.org/z/Povzd49T3


    constexpr const char LiteralWithUmlautsHex[] = "\xC3\xA4\xC3\xB6\xC3\xBC";
    constexpr const char8_t U8LiteralWithUmlautsHex[] = u8"\xE4\xF6\xFC";
    constexpr const char16_t U16LiteralWithUmlautsHex[] = u"\u00E4\u00F6\u00FC";
    constexpr const char32_t U32LiteralWithUmlautsHex[] = U"\U000000E4\U000000F6\U000000FC";
    constexpr const wchar_t WideLiteralWithUmlautsHex[] = L"\xE4\xF6\xFC";

    static_assert( sizeof( LiteralWithUmlautsHex ) == 7 );
    static_assert( sizeof( U8LiteralWithUmlautsHex ) == 7 );
    static_assert( sizeof( U16LiteralWithUmlautsHex ) == 8 );
    static_assert( sizeof( U32LiteralWithUmlautsHex ) == 16 );
    static_assert( sizeof( WideLiteralWithUmlautsHex ) == 8 );


    constexpr const char PlainLiteral[] = "aou";
    constexpr const char8_t U8PlainLiteral[] = u8"aou";
    constexpr const char16_t U16PlainLiteral[] = u"aou";
    constexpr const char32_t U32PlainLiteral[] = U"aou";
    constexpr const wchar_t WidePlainLiteral[] = L"aou";

    static_assert( sizeof( PlainLiteral ) == 4 );
    static_assert( sizeof( U8PlainLiteral ) == 4 );
    static_assert( sizeof( U16PlainLiteral ) == 8 );
    static_assert( sizeof( U32PlainLiteral ) == 16 );
    static_assert( sizeof( WidePlainLiteral ) == 8 );
}
