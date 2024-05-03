#include "File.hxx"

#include <filesystem>
#include <fstream>
#include <string>
#include <vector>

namespace ifchelper
{
    std::vector<std::byte> loadFile( const std::string& name )
    {
        std::filesystem::path path{ name };
        auto size = std::filesystem::file_size( path );
        std::vector<std::byte> v;
        v.resize( size );
        std::ifstream file( name, std::ios::binary );
        file.read( reinterpret_cast<char*>( v.data() ), static_cast<std::streamsize>( v.size() ) );
        return v;
    }
}
