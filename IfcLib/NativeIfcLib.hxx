#pragma once

#include <cstdint>
#include <string>

namespace ifchelper
{
    class IfcReader;
}

using NativeEnumCallback = bool( _cdecl* )( const char* name, const char* ns, bool enumClass, const char** members, int32_t memberCount );

ifchelper::IfcReader* CreateIfc( const std::string& ifcPath );
void DestroyIfc( ifchelper::IfcReader* ifc );
bool GetEnums( ifchelper::IfcReader* ifc, NativeEnumCallback callback );
