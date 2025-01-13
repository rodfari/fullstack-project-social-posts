import { useEffect, useState, useContext, useRef } from "react";
import { AppContext } from "../../../context/AppContext";
import RepostButton from "../RepostButton";
import { getPosts } from "../../../services/api-services";


const Posts = () => {

  const appCtx = useContext(AppContext);
  const [posts, setPosts] = useState([]);
  
  useEffect(() => {
    getPosts(appCtx.search, appCtx.sort).then((data) => {
      setPosts(data);
    });
  }, [appCtx.updatePost, appCtx.search, appCtx.sort, appCtx.repost]);


  const ctx = useContext(AppContext);
  if (!posts) {
    return <p>Loading...</p>;
  }
  if (posts.length === 0) {
    return (
      <div className="no-posts">
        <p>No posts found</p>
      </div>
    );
  }
  return (
    <>
      {posts.map((post) => (
        <div className="post-box" key={post.postId}>
          {post.isRepost && (
            <div className="repost">
              <span className="repost__badget">repost</span>
            </div>
          )}
          <div className="post">
            <div className="post__user">
              <div className="post__user-avatar">
                {post.username.charAt(0).toUpperCase()}
              </div>
              <div className="post__user-name">{post.username}</div>
            </div>
            <div className="post__content">
              {post.isRepost && <span className="repost-author">Author: {post.author}</span>}
              <p>{post.content}</p>
              <p className="post-date">{new Date(post.createdAt).toISOString().split("T")[0]}</p>
            </div>
            {post.userId != ctx.user.id && !post.isRepost && (
              <RepostButton
                userId={ctx.user.id}
                authorId={post.userId}
                originalPostId={post.postId}
              />
            )}
          </div>
        </div>
      ))}
    </>
  );
};

export default Posts;
