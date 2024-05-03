#pragma once

#include <ifc/abstract-sgraph.hxx>
#include <ifc/reader.hxx>

#include <string>

namespace ifchelper
{
    std::string buildScopeName( const ifc::Reader& reader, ifc::DeclIndex scopeIndex );

    std::string fullyQualifiedName( const ifc::Reader& reader, const ifc::symbolic::EnumerationDecl& enumeration );
}
