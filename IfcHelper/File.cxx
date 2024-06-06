#include "File.hxx"

#include <filesystem>
#include <fstream>
#include <string>
#include <vector>

#include <gsl/narrow>

namespace ifchelper
{
    std::vector<std::byte> loadFile( const std::string& name )
    {
        const std::filesystem::path path( name );
        std::vector<std::byte> buffer;
        buffer.resize( std::filesystem::file_size( path ) );
        if ( std::ifstream ifs( name, std::ios::binary ); ifs )
        {
#pragma warning( suppress : 26490 ) // Don't use reinterpret_cast (type.1).
            ifs.read( reinterpret_cast<char*>( buffer.data() ), gsl::narrow<std::streamsize>( buffer.size() ) );
            return buffer;
        }

        throw std::runtime_error( "Failed to open file: " + name );
    }
}
