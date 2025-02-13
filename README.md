# Kata User Register

## Description

This is a simple user registration use case. As a User I want to register to the platform providing an email and
password.

## Requirements

- It returns the newly created user
- The password should meet the security requirements:
    - Have more than 8 characters
    - Contains an underscore
- The userId should be random and unique
- The email should be a valid email
- The email cannot be used by another user
- A welcome email is sent to the newly registered user

## Remember

You could approach this kata using inside-out or outside-in but TDD is a must!.