# Sitemap Validator

A console application for validating URLs in sitemaps and ensuring they respond with a specified status code.

This is useful for brute force testing various pages and is an *extremely inefficient* way of doing it. 

Example:
```
SitemapValidator.exe -s https://example.com/sitemap.xml -c 200 -v -d 1000 -e test.csv
```

Breakdown

"-s" Url to sitemap
"-c" Expected HTTP Status Code
"-v" Verbose logging
"-d" Delay in miliseconds before each request
"-e" Export CSV filename 