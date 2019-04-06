param(
    [string]$projectPath = "../../client",
    [string]$tagName = "ideas-client"
)

### CLEANUP ###

# Delete previous outputs if exists
remove-item $projectPath/out -recurse -erroraction ignore
remove-item $projectPath/dist -recurse -erroraction ignore


### BUILD  ###

# Create ui output
npm run build --prefix $projectPath

# Create file static server output
dotnet publish -c release -o out -r linux-arm $projectPath


### PACKAGE ###

# Create docker image
docker build -t "marcussmallman/$tagName" $projectPath


### PUBLISH ###

# Push image to docker
docker push "marcussmallman/$tagName"


### DEPLOY ###

# Deploy to kubernetes
kubectl -n ideas apply -f ideas.yaml