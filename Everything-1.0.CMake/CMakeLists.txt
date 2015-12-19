
# Xamarin Studio sets environment variables that mess us up.
# FIXME: This only work the first time `make` is run. After that, `make` will
# fail if it rebuilds the .gir file because these don't take effect.
set(ENV{PKG_CONFIG_PATH} "/usr/local/lib/pkgconfig")
unset(ENV{PKG_CONFIG_LIBDIR})
unset(ENV{DYLD_FALLBACK_LIBRARY_PATH})

cmake_minimum_required(VERSION 2.8)
list (APPEND CMAKE_MODULE_PATH ${CMAKE_SOURCE_DIR}/cmake)
cmake_policy(SET CMP0042 OLD) # something to do with rpath on OSX

find_package(GirScanner REQUIRED)
find_package(GirCompiler REQUIRED)

# create the everything.h and everything.c source files
add_everything_source_files(EVERYTHING)

find_package(PkgConfig REQUIRED)
pkg_check_modules(EVERYTHING_DEPS REQUIRED
    glib-2.0
    gobject-2.0
)
add_definitions(${EVERYTHING_DEPS_CFLAGS})
link_libraries(${EVERYTHING_DEPS_LIBRARIES})
link_directories(${EVERYTHING_DEPS_LIBRARY_DIRS})

add_library(${EVERYTHING_LIB} SHARED ${EVERYTHING_C})

add_gir(EVERYTHING_GIR ${EVERYTHING_NAMESPACE} ${EVERYTHING_VERSION}
    DEPENDS
        GObject-2.0
    LIBRARY
        ${EVERYTHING_LIB}
    FILES
        ${EVERYTHING_H}
        ${EVERYTHING_C}
)
add_typelib(EVERYTHING_TYPELIB ${EVERYTHING_GIR})
add_custom_target(g-ir ALL DEPENDS ${EVERYTHING_GIR} ${EVERYTHING_TYPELIB})
