<?php

/*
    Author:- Vivek Kumar
    Date:- 2019-04-09
    Purpose:- User Class to manage actions: Login and SignUp with user details.
*/

class User{
 
    // database connection and table name
    private $conn;
    private $table_name = "users";
 
    // object properties
    public $id;
    public $username;
    public $password;
    public $created;
 
    // constructor with $db as database connection
    public function __construct($db){
        $this->conn = $db;
    }

    // login user method
    function login(){
        // select all query with user inputed username and password
        $query = "SELECT
                    `id`, `username`, `password`, `created`
                FROM
                    " . $this->table_name . " 
                WHERE
                    username='".$this->username."' AND password='".$this->password."'";
        // prepare query statement
        $stmt = $this->conn->prepare($query);
        // execute query
        $stmt->execute();
        return $stmt;
    }
}