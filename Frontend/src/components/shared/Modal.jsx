import { useContext, useState } from "react";
import { createPost } from "../../services/api-services";
import { AppContext } from "../../context/AppContext";
import { UserContext } from "../../context/UserContext";
import { ModalContext } from "../../context/ModalContext";
import { TimelineContext } from "../../context/TimeLineContext";

const Modal = () => {
  const userCtx = useContext(UserContext);
  const modalContext = useContext(ModalContext);
  const tmlCtx = useContext(TimelineContext);
  console.log(tmlCtx);
  const [errors, setErrors] = useState([]);

  const handleSubmit = (e) => {
    e.preventDefault();
    const fd = new FormData(e.target);
    const post = fd.get("post");
    const userId = userCtx.user.id;

    const body = { userId: userId, content: post };

    createPost(body).then((data) => {
      if (data.success === true) {
        modalContext.toggleModal((prev) => !prev);
        tmlCtx.setRefresh(true);
        return;
      }
      
      if (data.errors) {
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
            <div className="modal__close" onClick={modalContext.toggleModal}>
              x
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
