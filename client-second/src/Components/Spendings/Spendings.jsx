import React from "react";
import { useEffect, useState } from "react";
import axios from "axios";
import { Icon } from "@iconify/react";
import SpendingForm from "./SpendingForm/SpendingForm";

export default function Spendings() {
  const [spendings, setSpendings] = useState([]);
  const [spendingForm, setSpendingForm] = useState({
    spendingId: 0,
    value: 0,
    item: "",
    currency: 1,
  });
  const getAll = async () => {
    try {
      const response = await axios.get("spending/get-all");
      setSpendings(response.data);
    } catch (error) {
      alert(error);
    }
  };
  useEffect(() => getAll(), []);

  const clickUpdate = (spending) =>
    setSpendingForm((previous) => ({
      ...previous,
      spendingId: spending.id,
      value: spending.value,
      item: spending.item,
      currency: spending.currency,
    }));

  const clickDelete = (id) => {
    if (window.confirm("Are you sure?")) {
      axios
        .delete("/spending/detete/" + id)
        .then(getAll())
        .catch((error) => alert(error));
    }
  };
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
                  className="btn btn-light me-1"
                  data-bs-toggle="modal"
                  data-bs-target="#exampleModal"
                  onClick={clickUpdate(spending)}
                >
                  <Icon icon="material-symbols:edit-outline-sharp" />
                </button>

                <button
                  type="button"
                  className="btn btn-light me-1"
                  onClick={clickDelete(spending.id)}
                >
                  <Icon icon="material-symbols:delete-outline" />
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
      <SpendingForm data={spendingForm} getAllFunction={getAll} />
    </div>
  );
}
