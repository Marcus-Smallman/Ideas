FROM resin/rpi-raspbian

# Update and install mongo
RUN apt-get update && apt-get -y dist-upgrade
RUN apt-get install -y --no-install-suggests mongodb

# Setup volumes
VOLUME /data/db /data/configdb

# Set entrypoint
ENTRYPOINT /usr/bin/mongod

# Expose port
EXPOSE 27017

# Set default command
CMD ["mongod"]