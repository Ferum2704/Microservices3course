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
      console.log(error);
    }
  };
  useEffect(() => {
    axios
      .get("spending/get-all")
      .then((response) =>
        setSpendings(response.data).catch((error) => console.log(error))
      );
  }, []);
  const createClick = () => {
    axios
      .post("/spending/add", {
        id: spendingForm.spendingId,
        value: spendingForm.value,
        item: spendingForm.item,
        currency: spendingForm.currency,
      })
      .then(getAll())
      .catch((error) => console.log(error));
  };

  const updateClick = () => {
    axios
      .put("/spending/update", {
        id: spendingForm.spendingId,
        value: spendingForm.value,
        item: spendingForm.item,
        currency: spendingForm.currency,
      })
      .then(getAll())
      .catch((error) => console.log(error));
  };

  const changeSum = (e) =>
    setSpendingForm((previous) => ({
      ...previous,
      value: Number(e.target.value),
    }));
  const changeCategoryName = (e) =>
    setSpendingForm((previous) => ({ ...previous, item: e.target.value }));
  const clickUpdate = (spending) =>
    setSpendingForm({
      spendingId: spending.id,
      value: spending.sum,
      item: spending.item,
      currency: spending.currency,
    });

  const clickDelete = (id) => {
    if (window.confirm("Are you sure?")) {
      axios
        .delete("/spending/delete/" + id)
        .then(getAll())
        .catch((error) => console.log(error));
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
              <td>{spending.item}</td>
              <td>
                <button
                  type="button"
                  className="btn btn-light me-1"
                  data-bs-toggle="modal"
                  data-bs-target="#exampleModal"
                  onClick={() => clickUpdate(spending)}
                >
                  <Icon icon="material-symbols:edit-outline-sharp" />
                </button>

                <button
                  type="button"
                  className="btn btn-light me-1"
                  onClick={() => clickDelete(spending.id)}
                >
                  <Icon icon="material-symbols:delete-outline" />
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
      <div
        className="modal fade"
        id="exampleModal"
        tabIndex="-1"
        aria-hidden="true"
      >
        <div className="modal-dialog modal-lg modal-dialog-centered">
          <div className="modal-content">
            <div className="modal-header">
              <h5 className="modal-title">
                {spendingForm.spendingId !== 0 ? "Edit" : "Add"} Spending
              </h5>
              <button
                type="button"
                className="btn-close"
                data-bs-dismiss="modal"
                aria-label="Close"
              ></button>
            </div>

            <div className="modal-body">
              <div className="input-group mb-3">
                <span className="input-group-text">Sum</span>
                <input
                  type="text"
                  className="form-control"
                  value={spendingForm.value}
                  onChange={changeSum}
                />
              </div>
              <div className="input-group mb-3">
                <span className="input-group-text">Category Name</span>
                <input
                  type="text"
                  className="form-control"
                  value={spendingForm.item}
                  onChange={changeCategoryName}
                />
              </div>
              {spendingForm.spendingId === 0 ? (
                <button
                  type="button"
                  className="btn btn-primary float-start"
                  onClick={() => createClick()}
                >
                  Create
                </button>
              ) : null}

              {spendingForm.spendingId !== 0 ? (
                <button
                  type="button"
                  className="btn btn-primary float-start"
                  onClick={() => updateClick()}
                >
                  Update
                </button>
              ) : null}
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
