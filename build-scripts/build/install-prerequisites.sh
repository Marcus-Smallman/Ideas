# Update and install packages
sudo apt-get update
sudo apt-get install curl

# Download and install open-faas
curl -sSL https://cli.openfaas.com | sudo -E sh

# Download and install nodejs
curl -sL https://deb.nodesource.com/setup_11.x | sudo -E bash -
sudo apt-get install -y nodejs