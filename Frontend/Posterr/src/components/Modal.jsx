import { useContext, useState } from "react";
import { AppContext } from "../context/AppContext";
import { createPost } from "../services/api-services";

const Modal = () => {
  const ctx = useContext(AppContext);

  const [errors, setErrors] = useState([]);

  const handleSubmit = (e) => {
    e.preventDefault();
    const fd = new FormData(e.target);
    const post = fd.get("post");
    const userId = 2;

    const body = { userId: userId, content: post };
    createPost(body).then((data) => {
      console.log(`[SUCCESS]: ${data.success}`);
      console.log(data);
      if (data.success === true) {
        ctx.toggleModal((prev) => !prev);
        ctx.setUpdatePost((prex) => !prex);
        return;
      }

      if (data.errors) {
        console.log("has errors!");
        setErrors(data.errors);
      }

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
              <textarea
                placeholder="Write something..."
                id="post"
                name="post"
              ></textarea>
              { errors.length > 0 && (
                <div className="modal__errors">
                  {errors.map((error, index) => (
                    <p key={index}>{error.message}</p>
                  ))}
                </div>
              )}
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
