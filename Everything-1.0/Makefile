CFLAGS+=$(shell pkg-config --cflags gobject-2.0)
LDFLAGS+=$(shell pkg-config --libs gobject-2.0)
LIBTOOL?=glibtool

all: Everything-1.0.typelib

everything.stamp: Makefile
	g-ir-scanner --generate-typelib-tests=Everything,everything.h,everything.c
	touch $@

everything.c: everything.stamp
	@true

everything.h: everything.stamp
	@true

%.lo: %.c Makefile
	$(LIBTOOL) --tag=CC --mode=compile \
	$(CC) $(CFLAGS) $(CPPFLAGS) -c $<

libeverything-1.0.la: everything.lo Makefile
	$(LIBTOOL) --tag=CC --mode=link \
	$(CC) $(LDFLAGS) -o $@ $^ $(LDLIBS)

Everything-1.0.gir: libeverything-1.0.la Makefile
	g-ir-scanner --warn-all --warn-error --reparse-validate \
	--namespace=Everything --nsversion=1.0 \
	--libtool="$(LIBTOOL)" --library=libeverything-1.0.la \
	--output=$@ --include=GObject-2.0  -I$(@D) \
	--pkg-export=everything-1.0 \
	everything.h everything.c

%.typelib: %.gir Makefile
	g-ir-compiler $< -o $@

clean:
	$(LIBTOOL) --mode=clean rm -f *.lo *.la
	rm -f everything.* *.gir *.typelib
