@echo off
ECHO Running CallAddHosts

set hosts="website.com identity.website.com api.website.com mvc-implicit.website.com mvc-hybrid.website.com js.website.com react.website.com"
CD .\Scripts
.\AddHosts.cmd %hosts%