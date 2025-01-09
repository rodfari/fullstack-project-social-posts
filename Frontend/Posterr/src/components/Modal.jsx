import { useContext } from "react";
import { ModalContext } from "../context/ModalContext";

const Modal = () => {
    const ctx = useContext(ModalContext);
  return (
    <>
      <div className="backdrop">
        <div className="modal">
          <div className="modal__header">
            <div className="modal__title">New Post</div>
            <div className="modal__close" onClick={ ctx.toggleModal}>
              X
            </div>
          </div>
          <div className="modal__content">
            <textarea placeholder="Write something..."></textarea>
          </div>
          <div className="modal__footer">
            <button>Post</button>
          </div>
        </div>
      </div>
    </>
  );
};

export default Modal;
