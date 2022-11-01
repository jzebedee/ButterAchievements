#!/bin/sh

mkdir -p Native/Videos
cd Native/Videos

ffmpeg -t 0.02 -f lavfi -i color=c=black:s=1920x1080 -c:v vp8 -pix_fmt yuv420p -filter:v fps=30 TWLogo_and_Partners.ivf
ffmpeg -t 0.02 -f lavfi -i anullsrc -c:a libvorbis TWLogo_and_Partners.ogg

ffmpeg -t 0.02 -f lavfi -i color=c=black:s=1920x1080 -c:v libx264 -pix_fmt yuv420p -filter:v fps=30 TWLogo_and_Partners.mp4