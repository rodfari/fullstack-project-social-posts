import React, { useContext, useEffect } from 'react'
import { createRepost } from '../../services/api-services';
import { AppContext } from '../../context/AppContext';

const RepostButton = ({ userId, authorId, originalPostId }) => {
    const ctx = useContext(AppContext);
    
    const clickHandler = () => {  
        console.log(`[userId]: ${userId}`);
        console.log(`[authorId]: ${authorId}`);
        console.log(`[originalPostId]: ${originalPostId}`);
        createRepost({
            "authorId": authorId,
            "userId": userId,
            "originalPostId": originalPostId,
            "isRepost": true
          }).then(data => {
            console.log(data);
                ctx.setRepost((prev) => !prev);
          });
    
    };


  return (
    <div className="post__repost">
    <button onClick={ clickHandler }>Repost</button>
  </div>
  )
}

export default RepostButton