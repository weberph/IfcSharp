export module StringLiteralTests;

import <tuple>;

export inline void test() noexcept
{
    std::ignore = "test_default";
    std::ignore = u8"test_u8";
    std::ignore = u"test_u16";
    std::ignore = U"test_u32";
    std::ignore = L"test_wide";
}
