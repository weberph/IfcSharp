#pragma once

#include "File.hxx"

#include <ifc/reader.hxx>
#include <ifc/dom/node.hxx>
#include <ifc/index-utils.hxx>

#include <vector>
#include <memory>
#include <stdexcept>

namespace ifchelper
{
    class BufferedIfc
    {
    public:
        static constexpr ifc::IfcOptions DefaultValidationOptions = static_cast<ifc::IfcOptions>( ifc::to_underlying( ifc::IfcOptions::IntegrityCheck ) | ifc::to_underlying( ifc::IfcOptions::AllowAnyPrimaryInterface ) );

        explicit BufferedIfc( std::vector<std::byte> buffer )
            : mBuffer( std::make_shared<std::vector<std::byte>>( std::move( buffer ) ) )
            , mInputIfc( std::span( *mBuffer ) )
        {
        }

        const ifc::InputIfc& inputIfc() const noexcept
        {
            return mInputIfc;
        }

        bool validate( ifc::IfcOptions validationOptions = DefaultValidationOptions )
        {
            ifc::Pathname emptyPath{};
            return mInputIfc.validate<ifc::UnitSort::Primary>( emptyPath, ifc::Architecture::Unknown, emptyPath, validationOptions );
        }

        static BufferedIfc loadFile( const std::string& ifcPath, ifc::IfcOptions validationOptions = DefaultValidationOptions )
        {
            BufferedIfc bufferedIfc{ ifchelper::loadFile( ifcPath ) };
            if ( not bufferedIfc.validate( validationOptions ) )
            {
                throw std::runtime_error( "Invalid ifc file: " + ifcPath );
            }
            return bufferedIfc;
        }

    private:
        std::shared_ptr<std::vector<std::byte>> mBuffer;
        ifc::InputIfc mInputIfc;
    };

    class IfcReader
    {
    public:
        explicit IfcReader( BufferedIfc ifc )
            : mBufferedIfc( std::move( ifc ) )
            , mReader( std::make_unique<ifc::Reader>( mBufferedIfc.inputIfc() ) )
            , mLoader( std::make_unique<ifc::util::Loader>( *mReader ) )
        {
        }

        ifc::Reader& reader() noexcept
        {
            return *mReader;
        }

        ifc::util::Loader& loader() noexcept
        {
            return *mLoader;
        }

        static IfcReader loadFile( const std::string& ifcPath )
        {
            return IfcReader{ BufferedIfc::loadFile( ifcPath ) };
        }

    private:
        BufferedIfc mBufferedIfc;
        std::unique_ptr<ifc::Reader> mReader;
        std::unique_ptr<ifc::util::Loader> mLoader;
    };
}
