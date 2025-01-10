import { useContext } from "react";
import { ModalContext } from "../context/ModalContext";
import { createPost } from "../services/api-services";

const Modal = () => {
  const ctx = useContext(ModalContext);

  const handleSubmit = (e) => {
    e.preventDefault();
    const fd = new FormData(e.target);
    const post = fd.get("post");
    const userId = 2;

    const body = { "userId": userId, "content": post};
    createPost(body).then((data) => {
      console.log(data);
    });
  };

  return (
    <>
      <div className="backdrop">
        <div className="modal">
          <div className="modal__header">
            <div className="modal__title">New Post</div>
            <div className="modal__close" onClick={ctx.toggleModal}>
              X
            </div>
          </div>
          <form onSubmit={handleSubmit}>
            <div className="modal__content">
              <label htmlFor="post">Write a post.</label>
              <textarea placeholder="Write something..." id="post" name="post"></textarea>
            </div>
            <div className="modal__footer">
              <button type="submit">Post</button>
            </div>
          </form>
        </div>
      </div>
    </>
  );
};

export default Modal;
