#include <format>
#include <string>
#include <stdexcept>

void ifc_assert( const char* text, const char* file, int line )
{
    throw std::runtime_error( std::format( "assertion failure: ``{}'' in file ``{}'' at line {}", text, file, line ) );
}

void ifc_verify( const char* text, const char* file, int line )
{
    throw std::runtime_error( std::format( "verify failure: ``{}'' in file ``{}'' at line {}", text, file, line ) );
}
