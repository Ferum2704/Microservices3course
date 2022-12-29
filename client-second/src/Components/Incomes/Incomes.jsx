import React from "react";
import { useEffect, useState } from "react";
import axios from "axios";
import { Icon } from "@iconify/react";
export default function Incomes() {
  const [incomes, setIncomes] = useState([]);
  useEffect(() => {
    axios.get("/income/get").then((response) => {
      const received = response.data;
      setIncomes(received);
    });
  }, []);
  return (
    <div>
      <button
        type="button"
        className="btn btn-primary m-2 float-end"
        data-bs-toggle="modal"
        data-bs-target="#exampleModal"
      >
        Add Income
      </button>
      <table className="table table-striped">
        <thead>
          <tr>
            <th>Sum</th>
            <th>Category Name</th>
            <th>Date</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {incomes.map((income) => (
            <tr key={income.id}>
              <td>{income.sum}</td>
              <td>{income.categoryName}</td>
              <td>{income.date}</td>
              <td>
                <button
                  type="button"
                  className="btn btn-light mr-1"
                  data-bs-toggle="modal"
                  data-bs-target="#exampleModal"
                >
                  <Icon icon="material-symbols:edit-outline-sharp" />
                </button>

                <button type="button" className="btn btn-light mr-1">
                  <Icon icon="material-symbols:delete-outline" />
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
