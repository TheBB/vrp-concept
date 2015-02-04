SRCDIR = src
LIBDIR = libvrp
OUTDIR = build

_LIBSRCS = Solver.cs
_BINSRCS = Main.cs

_LIB = libvrp
_BIN = vrp-concept

COMPILER = mcs
MCSFLAGS =

ifdef DEBUG
	MCSFLAGS := $(MCSFLAGS) -d:DEBUG
endif

LIBSRCS = $(patsubst %,$(SRCDIR)/$(LIBDIR)/%,$(_LIBSRCS))
BINSRCS = $(patsubst %,$(SRCDIR)/%,$(_BINSRCS))

LIB = $(OUTDIR)/$(_LIB).dll
BIN = $(OUTDIR)/$(_BIN)
ALL = $(LIB) $(BIN)

all: bin

lib: $(LIB)

bin: $(BIN)

$(LIB): $(LIBSRCS)
	$(COMPILER) $(MCSFLAGS) -target:library -out:$(LIB) $(LIBSRCS)

$(BIN): $(LIB) $(BINSRCS)
	$(COMPILER) $(MCSFLAGS) -out:$(BIN) -reference:$(LIB) $(BINSRCS)

clean:
	rm -f $(ALL)