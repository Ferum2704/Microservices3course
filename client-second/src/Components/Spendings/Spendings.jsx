import React from "react";
import { useEffect, useState } from "react";
import axios from "axios";
import { Icon } from "@iconify/react";
export default function Spendings() {
  const [spendings, setSpendings] = useState([]);
  useEffect(() => {
    axios.get("/spending/get").then((response) => {
      const received = response.data;
      setSpendings(received);
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
        Add Spending
      </button>
      <table className="table table-striped">
        <thead>
          <tr>
            <th>Sum</th>
            <th>Category Name</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {spendings.map((spending) => (
            <tr key={spending.id}>
              <td>{spending.value}</td>
              <td>{spendings.item}</td>
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
