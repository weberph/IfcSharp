#pragma once

#include "NativeIfcLib.hxx"

#include <cstdint>

// including ifc headers does not work; clr does not support char8_t (and possibly more): 
// https://developercommunity.visualstudio.com/t/char8_t-is-not-recognized-in-CCLI-wit/10490407

namespace IfcLib
{
    public ref struct IfcEnum
    {
        System::String^ Name;
        System::String^ Namespace;
        bool EnumClass;
        array<System::String^>^ Members;

        IfcEnum( System::String^ name, System::String^ ns, bool enumClass, array<System::String^>^ members )
            : Name( name )
            , Namespace( ns )
            , EnumClass( enumClass )
            , Members( members )
        {
        }
    };

    public ref class Ifc
    {
    public:
        Ifc( System::String^ filePath );

        System::Collections::Generic::List<IfcEnum^>^ GetEnums();

        ~Ifc()
        {
            if ( mReader )
            {
                DestroyIfc( mReader );
                mReader = nullptr;
            }
        }

    protected:
        !Ifc()
        {
            if ( mReader )
            {
                DestroyIfc( mReader );
                mReader = nullptr;
            }
        }

    private:
        ifchelper::IfcReader* mReader;
    };
}
