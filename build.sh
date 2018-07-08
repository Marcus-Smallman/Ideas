# Update and install packages
sudo apt-get update
sudo apt-get install curl

# Download and install open-faas
curl -sSL https://cli.openfaas.com | sudo -E sh

# Build function(s)
faas-cli build -f idea-fn.yml