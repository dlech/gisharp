
# minimum version needed for cmake_parse_arguments
cmake_minimum_required(VERSION 2.8.3)

find_program(G_IR_COMPILER_EXEC NAMES g-ir-compiler)
mark_as_advanced(G_IR_COMPILER_EXEC)

# Creates a gobject introspecion .typelib from a .gir file
#
# Usage: add_typelib(TYPELIB GIR)
#
# TYPELIB: Output variable name for the .typelib file that will be created
# GIR: The name of the .gir file
#
function(add_typelib TYPELIB GIR)
    string(REPLACE ".gir" ".typelib" TYPELIB_FILE_NAME ${GIR})

    # output variable
    set(${TYPELIB} ${TYPELIB_FILE_NAME} PARENT_SCOPE)

    add_custom_command(
        OUTPUT
            ${TYPELIB_FILE_NAME}
        COMMAND
            ${G_IR_COMPILER_EXEC}
        ARGS
            ${GIR}
            -o ${TYPELIB_FILE_NAME}
        DEPENDS
            ${GIR}
        COMMENT
            "Generating ${TYPELIB_FILE_NAME}"
    )
endfunction()
