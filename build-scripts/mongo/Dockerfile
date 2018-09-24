FROM resin/rpi-raspbian

# Update and install mongo (current version for armhf 2.4.10)
RUN apt-get update && apt-get -y dist-upgrade
RUN apt-get install -y --no-install-suggests mongodb=1:2.4.10-5+deb8u1

# Setup volumes
VOLUME /data/db /data/configdb

# Set entrypoint
ENTRYPOINT /usr/bin/mongod

# Expose port
EXPOSE 27017

# Set default command
CMD ["mongod"]