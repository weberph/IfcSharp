#include "IfcLib.hxx"
#include "NativeIfcLib.hxx"

#include <vcclr.h>

#include <string>

using namespace System;
using namespace System::Collections::Generic;

namespace IfcLib
{
    namespace
    {
        // including <msclr\marshal_cppstd.h> produces warnings and/or errors (e.g. if a "using" is used before the include)
        std::string to_string( String^ str )
        {
            const pin_ptr<const wchar_t> wptr = PtrToStringChars( str );
            const auto charCount = str->Length;

            std::string result;
            result.reserve( charCount );
            for ( size_t i = 0; i < charCount; i++ )
            {
                result[i] = static_cast<char>( wptr[i] );
            }
            return result;
        }
    }

    Ifc::Ifc( String^ filePath )
        : mReader( CreateIfc( to_string( filePath ) ) )
    {
    }

    List<IfcEnum^>^ Ifc::GetEnums()
    {
        List<IfcEnum^>^ enums = gcnew List<IfcEnum^>(1);

        // no lambdas allowed :(
        ::GetEnums( mReader, []( const char* name, const char* ns, bool enumClass, const char** members, int32_t memberCount ) {
            //enums->Add( nullptr );
            return true;
        });
    }
}
