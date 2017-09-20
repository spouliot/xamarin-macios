# usage $(call CheckSubmoduleTemplate (name,MAKEFILE VAR,repo name))
# usage $(call CheckSubmoduleTemplate (mono,MONO,mono))

COLOR_GRAY:=$(shell tput setaf 250 2>/dev/null)
COLOR_GREEN:=$(shell tput setaf 120 2>/dev/null)
COLOR_RED:=$(shell tput setaf 1 2>/dev/null)
COLOR_CLEAR:=$(shell tput sgr0 2>/dev/null)

define CheckSubmoduleTemplate
#$(eval NEEDED_$(2)_VERSION:=$(shell git --git-dir $(abspath $($(2)_PATH)/../..)/.git --work-tree $(abspath $($(2)_PATH)/../..) ls-tree HEAD --full-tree -- external/$(1) | awk -F' ' '{printf "%s",$$3}'))
#$(eval $(2)_VERSION:=$$$$(shell cd $($(2)_PATH) 2>/dev/null && git rev-parse HEAD 2>/dev/null))

check-$(1)::
ifeq ($$(IGNORE_$(2)_VERSION),)
	@if test ! -d $($(2)_PATH); then \
		if test x$$(RESET_VERSIONS) != "x"; then \
			make reset-$(1) || exit 1; \
		else \
			echo "Your $(1) checkout is $(COLOR_RED)missing$(COLOR_CLEAR), please run 'git submodule update --init --recursive -- external/$(1)'"; \
			touch .check-versions-failure; \
		fi; \
	else \
		if test "x$($(2)_VERSION)" != "x$(NEEDED_$(2)_VERSION)" ; then \
			if test x$$(RESET_VERSIONS) != "x"; then \
				make reset-$(1) || exit 1; \
			else \
				echo "Your $(1) version is $(COLOR_RED)out of date$(COLOR_CLEAR), please run 'make reset-$(1)' (found $($(2)_VERSION), expected $(NEEDED_$(2)_VERSION)). Alternatively export IGNORE_$(2)_VERSION=1 to skip this check."; \
				test -z "$(BUILD_REVISION)" || $(MAKE) test-$(1); \
				touch .check-versions-failure; \
			fi; \
		else \
			echo "$(1) is $(COLOR_GREEN)up-to-date$(COLOR_CLEAR)."; \
		fi; \
	fi
else
	@echo "$(1) is $(COLOR_GRAY)ignored$(COLOR_CLEAR)."
endif

test-$(1)::
	@echo $(1)
	@echo "   NEEDED_$(2)_VERSION=$(NEEDED_$(2)_VERSION)"
	@echo "   $(2)_VERSION=$($(2)_VERSION)"
	@echo "   $(2)_PATH=$($(2)_PATH) => $(abspath $($(2)_PATH))"

reset-$(1)::
ifneq ($$(IGNORE_$(2)_VERSION),)
	@echo "*** Not resetting $(1) because IGNORE_$(2)_VERSION is set"
else
	@echo "*** git submodule update --init --recursive --force -- $(TOP)/external/$(1)"
	cd $(abspath $($(2)_PATH)/../..) && git submodule update --init --recursive --force -- ./external/$(1)
endif

print-$(1)::
	@printf "*** %-16s %-45s %s (%s)\n" "$(1)" "$(shell git config submodule.external/$(1).url)" "$(NEEDED_$(2)_VERSION)" "$(shell git config -f $(abspath $(TOP)/.gitmodules) submodule.external/$(1).branch)"

.PHONY: check-$(1) reset-$(1) print-$(1)

reset-versions:: reset-$(1)
check-versions:: check-$(1)
print-versions:: print-$(1)
endef


$(shell rm -f .check-versions-failure)
$(eval $(call CheckSubmoduleTemplate,llvm,LLVM))
$(eval $(call CheckSubmoduleTemplate,mono,MONO))
$(eval $(call CheckSubmoduleTemplate,fsharp,FSHARP))
$(eval $(call CheckSubmoduleTemplate,MonoTouch.Dialog,MONOTOUCH_DIALOG))
$(eval $(call CheckSubmoduleTemplate,Touch.Unit,TOUCH_UNIT))
$(eval $(call CheckSubmoduleTemplate,opentk,OPENTK))
$(eval $(call CheckSubmoduleTemplate,Xamarin.MacDev,XAMARIN_MACDEV))
$(eval $(call CheckSubmoduleTemplate,guiunit,GUI_UNIT))

include $(TOP)/mk/xamarin.mk

# some hackish reset-* targets to deal with what needs to happen in various parts of the build tree when you reset a module

reset-mono::
	$(Q) rm -f $(TOP)/.stamp-build* $(MONO_PATH)/configure

reset-llvm::
	$(Q) $(MAKE) -C $(TOP)/builds clean-llvm

reset-fsharp::
	$(Q) cd $(FSHARP_PATH) && git clean -xffdq

check-versions::
	@if test -e .check-versions-failure; then  \
		rm .check-versions-failure; \
		echo "$(COLOR_RED)One or more modules needs update$(COLOR_CLEAR)";  \
		exit 1; \
	else \
		echo All dependent modules up to date;  \
	fi

all-local:: check-versions

reset:
	@make check-versions RESET_VERSIONS=1
