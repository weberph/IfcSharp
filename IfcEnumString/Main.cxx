#include <iostream>
#include <filesystem>
#include <fstream>
#include <cstdlib>
#include <string>
#include <stdexcept>
#include <format>
#include <memory>

#include <IfcHelper.hxx>

#include <ifc/reader.hxx>
#include <ifc/dom/node.hxx>
#include <ifc/index-utils.hxx>

#include <gsl/span>

#pragma comment(lib, "bcrypt.lib")

int main()
{
    //std::string name = R"(d:\.projects\.unsorted\2024\CppEnumString\CppEnumStringTest\x64\Debug\ExportedEnums.ixx.ifc)";
    std::string name = R"(d:\.projects\.unsorted\2024\WrapAllInModuleTest\WrapAllInModuleTest\x64\Debug\Everything.ixx.ifc)";

    auto ifc = ifchelper::IfcReader::loadFile( name );
    auto& reader = ifc.reader();
    auto& loader = ifc.loader();

    auto enums = reader.partition<ifc::symbolic::EnumerationDecl>();
    for ( const auto& decl : enums )
    {
        std::cout << "Enum: " << ifchelper::fullyQualifiedName( reader, decl ) << std::endl;

        std::cout << "Values:" << std::endl;
        for ( const auto& val : reader.sequence( decl.initializer ) )
        {
            const auto valueName = loader.ref( val.identity );
            std::cout << "  " << valueName << std::endl;
        }

        std::cout << std::endl;
    }

    auto types = reader.partition<ifc::symbolic::ScopeDecl>();
    for ( const auto& decl : types )
    {
        if ( decl.type.sort() == ifc::TypeSort::Fundamental )
        {
            const auto& typeOfType = reader.get<ifc::symbolic::FundamentalType>( decl.type );
            if ( typeOfType.basis == ifc::symbolic::TypeBasis::Class || typeOfType.basis == ifc::symbolic::TypeBasis::Struct )
            {
                std::cout << "Type: " << reader.get( static_cast<ifc::TextOffset>( decl.identity.name.index() ) ) << std::endl;

                if ( const auto* initScope = reader.try_get( decl.initializer ) )
                {
                    for ( const auto& innerDeclaration : reader.sequence( *initScope ) )
                    {
                        if ( innerDeclaration.index.sort() == ifc::DeclSort::Field )
                        {
                            const auto& innerDecl = reader.get<ifc::symbolic::FieldDecl>( innerDeclaration.index );
                            std::cout << "Field: " << reader.get( innerDecl.identity.name ) << std::endl;
                        }
                    }
                }
            }
        }

        std::cout << std::endl;
    }
}
