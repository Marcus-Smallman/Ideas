param(
    [string]$projectPath = "../../client",
    [string]$tagName = "ideas-client"
)

# Delete previous output if exists
remove-item $projectPath/out -recurse -erroraction ignore

# Create output
dotnet publish -c release -o out -r linux-arm $projectPath

# Create docker image
docker build -t "marcussmallman/$tagName" $projectPath

# Push image
docker push "marcussmallman/$tagName"

# Deploy
kubectl -n ideas apply -f ideas.yaml