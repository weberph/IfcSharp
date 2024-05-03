#include "TypeName.hxx"

#include <ifc/abstract-sgraph.hxx>
#include <ifc/index-utils.hxx>
#include <ifc/reader.hxx>

#include <string>
#include <stdexcept>
#include <sstream>

namespace ifchelper
{
    template<class T>
    std::tuple<ifc::TextOffset, ifc::DeclIndex> getIdAndScope( const ifc::Reader& reader, const ifc::DeclIndex scope )
    {
        const auto& decl = reader.get<T>( scope );
        return std::make_tuple( static_cast<ifc::TextOffset>( decl.identity.name.index() ), decl.home_scope );
    }

    std::tuple<ifc::TextOffset, ifc::DeclIndex> getIdAndScope( const ifc::Reader& reader, const ifc::DeclIndex scope )
    {
        switch ( scope.sort() )
        {
            case ifc::DeclSort::Scope: return getIdAndScope<ifc::symbolic::ScopeDecl>( reader, scope );
            case ifc::DeclSort::Template: return getIdAndScope<ifc::symbolic::TemplateDecl>( reader, scope );
            case ifc::DeclSort::PartialSpecialization: return getIdAndScope<ifc::symbolic::PartialSpecializationDecl>( reader, scope );
            default: throw std::runtime_error( "getIdAndScope: sort not implemented" );
        }
    }

    bool buildScopeName( const ifc::Reader& reader, const ifc::DeclIndex outerScope, std::ostringstream& os )
    {
        if ( not index_like::null( outerScope ) )
        {
            const auto& [id, homeScope] = getIdAndScope( reader, outerScope );
            if ( const bool done = buildScopeName( reader, homeScope, os ); not done )
            {
                os << "::";
            }

            os << reader.get( id );
            return false;
        }

        return true;
    }

    std::string buildScopeName( const ifc::Reader& reader, ifc::DeclIndex scopeIndex )
    {
        std::ostringstream os;
        buildScopeName( reader, scopeIndex, os );
        return os.str();
    }

    std::string fullyQualifiedName( const ifc::Reader& reader, const ifc::symbolic::EnumerationDecl& enumeration )
    {
        std::ostringstream os;
        buildScopeName( reader, enumeration.home_scope, os );
        os << "::" << reader.get( enumeration.identity.name );
        return os.str();
    }
}