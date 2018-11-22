# Build function(s)
faas-cli build -f ideas.yml

# Build client
cd client
npm install # Install packages
npm run lint # Run lint step
npm run build # Run build step