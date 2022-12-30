import React from "react";
import { useState } from "react";
import axios from "axios";
export default function SpendingForm(props) {
  const [spendingForm, setSpendingForm] = useState({
    spendingId: props.data.spendingId,
    value: props.data.value,
    item: props.data.item,
    currency: props.data.currency,
  });

  const createClick = () => {
    axios
      .post("/spending/add", {
        id: spendingForm.spendingId,
        value: spendingForm.value,
        item: spendingForm.item,
        currency: spendingForm.currency,
      })
      .then(props.getAllFunction())
      .catch((error) => alert(error));
  };

  const updateClick = () => {
    axios
      .put("/spending/update", {
        id: spendingForm.spendingId,
        value: spendingForm.value,
        item: spendingForm.item,
        currency: spendingForm.currency,
      })
      .then(props.getAllFunction())
      .catch((error) => alert(error));
  };

  const changeSum = (e) =>
    setSpendingForm((previous) => ({
      ...previous,
      value: Number(e.target.value),
    }));
  const changeCategoryName = (e) =>
    setSpendingForm((previous) => ({ ...previous, item: e.target.value }));
  return (
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
                onClick={createClick}
              >
                Create
              </button>
            ) : null}

            {spendingForm.spendingId !== 0 ? (
              <button
                type="button"
                className="btn btn-primary float-start"
                onClick={updateClick}
              >
                Update
              </button>
            ) : null}
          </div>
        </div>
      </div>
    </div>
  );
}
