git basics

## Getting Latest changes on branch that exists locally or remotely

```
git fetch
git checkout <branch_name>
git pull --rebase
```

## Creating a new branch and publishing it to be tracked remotely

```
git checkout -b <branch_name>
git push -u origin <branch_name>
```

## Adding changes and pushing them up remotely

```
git add .
git commit -m "<commit_message>"
git push
```