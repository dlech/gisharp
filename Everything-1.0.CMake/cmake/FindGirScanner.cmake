
# minimum version needed for cmake_parse_arguments
cmake_minimum_required(VERSION 2.8.3)

find_program(G_IR_SCANNER_EXEC NAMES g-ir-scanner)
mark_as_advanced(G_IR_SCANNER_EXEC)

# Creates a gobject introspection .gir file
#
# Usage: add_gir(GIR NAMESPACE VERSION LIBRARY <library> [DEPENDS <gir1> ...]
#                [PACKAGES <pkg1] ...] FILES <file1> ...)
#
# GIR: Output variable name for the .gir file that will be created
# NAMESPACE: The namespace of the .gir
# VERSION: The version of the .gir
# LIBRARY: The shared library name for the .gir (omit "lib" prefix and file extension)
# DEPENDS: List of dependency girs
# PACKAGES: List of dependency pkg-config packages
# FILES: List of source code files
#
function(add_gir GIR NAMESPACE VERSION)
    set (GIR_FILE_NAME ${NAMESPACE}-${VERSION}.gir)

    # output variable
    set(${GIR} ${GIR_FILE_NAME} PARENT_SCOPE)

    set(options)
    set(one_value_keywords LIBRARY)
    set(multi_value_keywords DEPENDS PACKAGES FILES)
    cmake_parse_arguments(ARG "${options}" "${one_value_keywords}"
        "${multi_value_keywords}" ${ARGN})

    if(ARG_LIBRARY)
        set(LIBRARY_OPTIONS
            --library=${ARG_LIBRARY}
            --library-path=${CMAKE_BINARY_DIR}
            --pkg-export=${ARG_LIBRARY}
        )
    endif()

    if(ARG_DEPENDS)
        foreach(INCLUDE IN LISTS ARG_DEPENDS)
            list(APPEND INCLUDE_OPTIONS --include=${INCLUDE})
        endforeach()
    endif()

    if(ARG_PACKAGES)
        foreach(PACKAGE IN LISTS ARG_PACKAGES)
            list(APPEND PACKAGE_OPTIONS --pkg=${PACKAGE})
        endforeach()
    endif()

    add_custom_command(
        OUTPUT
            ${GIR_FILE_NAME}
        COMMAND
            ${G_IR_SCANNER_EXEC}
        ARGS
            --warn-all
            --warn-error
            --reparse-validate
            --no-libtool
            --namespace=${NAMESPACE}
            --nsversion=${VERSION}
            --output=${GIR_FILE_NAME}
            ${LIBRARY_OPTIONS}
            ${INCLUDE_OPTIONS}
            ${PACKAGE_OPTIONS}
            ${ARG_FILES}
        DEPENDS
            ${ARG_FILES} ${ARG_LIBRARY}
        COMMENT
            "Generating ${GIR_FILE_NAME}"
    )
endfunction()

# Generates source code files for the everything test library.
#
# Usage: add_everything_source_files(PREFIX)
#
# PREFIX: Used as prefix for output variables.
#
# Output variables:
# <PREFIX>_NAMESPACE: Contains the namespace of the everything library
# <PREFIX>_VERSION: Contains the version of the everything library
# <PREFIX>_H: Contains the name of the header file
# <PREFIX>_C: Contains the name of the C source code file
# <PREFIX>_LIB: The library name to pass to add_library()
#
function(add_everything_source_files PREFIX)
    set(NAMESPACE "Everything")
    set(VERSION "1.0")
    string(TOLOWER ${NAMESPACE} NAME)
    set(HEADER_FILE ${NAME}.h)
    set(SOURCE_FILE ${NAME}.c)

    # output variables
    set(${PREFIX}_NAMESPACE ${NAMESPACE} PARENT_SCOPE)
    set(${PREFIX}_VERSION ${VERSION} PARENT_SCOPE)
    set(${PREFIX}_H ${HEADER_FILE} PARENT_SCOPE)
    set(${PREFIX}_C ${SOURCE_FILE} PARENT_SCOPE)
    set(${PREFIX}_LIB "${NAME}-${VERSION}" PARENT_SCOPE)

    add_custom_command(
        OUTPUT
            ${HEADER_FILE}
            ${SOURCE_FILE}
        COMMAND
            ${G_IR_SCANNER_EXEC}
        ARGS
            --generate-typelib-tests=${NAMESPACE},${HEADER_FILE},${SOURCE_FILE}
        COMMENT
            "Generating ${HEADER_FILE} and ${SOURCE_FILE}"
    )
endfunction()
