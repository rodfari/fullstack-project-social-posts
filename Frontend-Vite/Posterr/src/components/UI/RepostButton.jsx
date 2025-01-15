import React, { useContext, useEffect } from "react";
import { createRepost } from "../../services/api-services";
import { AppContext } from "../../context/AppContext";
import Swal from "sweetalert2";

const RepostButton = ({ userId, authorId, originalPostId }) => {
  const ctx = useContext(AppContext);

  const clickHandler = () => {
    Swal.fire({
      title: "Do you want to repost it?",
      text: "You won't be able to revert this!",
      icon: "warning",
      reverseButtons: true,
      showCancelButton: true,
      confirmButtonColor: "#2ca844",
      cancelButtonColor: "#d33",
      confirmButtonText: "Respost it!",
    }).then((result) => {
      if (result.isConfirmed) {

        createRepost({
          authorId: authorId,
          userId: userId,
          originalPostId: originalPostId,
          isRepost: true,
        }).then((data) => {
          if(data.success){
            ctx.setRepost((prev) => !prev);
          }else{
            const errors = data.errors;
            Swal.fire({
              icon: "error",
              title: "Oops...",
              text: errors[0].message
            });
          }
        });
        
      }
    });
  };

  return (
    <div className="post__repost">
      <button onClick={clickHandler}>Repost</button>
    </div>
  );
};

export default RepostButton;
