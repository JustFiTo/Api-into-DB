# Create script in script.sql:

mysqldump -h 127.0.0.1 -u root --opt API > Script.sql


# Import DB with data:

mysql -h 127.0.0.1 -u root API < script.sql