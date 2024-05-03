#include <IfcHelper.hxx>

#include <string>

#pragma comment(lib, "bcrypt.lib")

#include <Windows.h>

using EnumCallback = bool( _cdecl* )( const char* name, const char* ns, bool enumClass, const char** members, int32_t memberCount );

extern "C" _declspec( dllexport ) ifchelper::IfcReader * CreateIfc( const char* ifcPath )
{
    try
    {
        return new ifchelper::IfcReader( ifchelper::IfcReader::loadFile( ifcPath ) );
    }
    catch ( const std::exception& e )
    {
        OutputDebugStringA( e.what() );
        return nullptr;
    }
}

extern "C" _declspec( dllexport ) void DestroyIfc( ifchelper::IfcReader * ifc )
{
    if ( ifc )
    {
        delete ifc;
    }
}

extern "C" _declspec( dllexport ) bool GetEnums( ifchelper::IfcReader * ifc, EnumCallback callback )
{
    if ( !ifc )
    {
        return false;
    }

    try
    {
        auto& reader = ifc->reader();
        auto& loader = ifc->loader();

        auto enums = reader.partition<ifc::symbolic::EnumerationDecl>();
        for ( const auto& decl : enums )
        {
            const auto ns = ifchelper::buildScopeName( reader, decl.home_scope );
            const auto* name = reader.get( decl.identity.name );

            const auto initializerSequence = reader.sequence( decl.initializer );
            std::vector<const char*> members( initializerSequence.size() );

            for ( size_t i = 0; i < initializerSequence.size(); i++ )
            {
                members.at( i ) = reader.get( initializerSequence[i].identity.name );
            }

            if ( not callback( name, ns.c_str(), true, members.data(), static_cast<int32_t>( members.size() ) ) )
            {
                break;
            }

        }
    }
    catch ( const std::exception& e )
    {
        OutputDebugStringA( e.what() );
        return false;
    }

    return true;
}
