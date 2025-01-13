import { useContext } from "react";
import { AppContext } from "../../../context/AppContext";
import RepostButton from "../RepostButton";

const Posts = ({ data }) => {
  const ctx = useContext(AppContext);
  if (!data) {
    return <p>Loading...</p>;
  }
  if (data.length === 0) {
    return (
      <div className="no-posts">
        <p>No posts found</p>
      </div>
    );
  }
  console.log(data);
  return (
    <>
      {data.map((post) => (
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
              {post.isRepost && <p>Author: {post.author}</p>}
              <p>{post.content}</p>
              <p>{new Date(post.createdAt).toISOString().split("T")[0]}</p>
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
