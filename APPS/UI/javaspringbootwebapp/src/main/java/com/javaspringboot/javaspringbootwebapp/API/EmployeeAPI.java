package com.javaspringboot.javaspringbootwebapp.API;

import org.springframework.web.bind.annotation.RestController;

import com.javaspringboot.javaspringbootwebapp.Models.EmployeesModel;

import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;


@RestController
public class EmployeeAPI {

    @GetMapping(value = "/getAllEmployee", produces = "application/json")
    public ResponseEntity<EmployeesModel[]> getAllEmployee() {
        System.out.println("getAllEmployee API called");
        return ResponseEntity.ok(new EmployeesModel[] {
            new EmployeesModel() {
                {
                    id = 1;
                    name = "John Doe";
                    email = "john.doe@example.com";
                }
            }
        });
    }


}
