#pragma once

#include <ifc/abstract-sgraph.hxx>

#include <string_view>

namespace ifchelper
{
    std::string_view to_string( ifc::TypeSort val ) noexcept;
    std::string_view to_string( ifc::DeclSort val ) noexcept;
    std::string_view to_string( ifc::ExprSort val ) noexcept;
    std::string_view to_string( ifc::symbolic::TypeBasis val ) noexcept;
}
