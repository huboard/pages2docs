FROM fsharp/fsharp
COPY build /app
EXPOSE 5000
ENTRYPOINT ["mono", "/app/pages2docs.exe"]
