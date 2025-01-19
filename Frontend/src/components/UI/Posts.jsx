import { forwardRef } from "react";
import RepostButton from "./RepostButton";

const Posts = forwardRef(({ post, userId }, ref) => {
  return (
    <div ref={ref} className="post-box" key={post.postId}>
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
          {post.isRepost && (
            <span className="repost-author">Author: {post.author}</span>
          )}
          <p>{post.content}</p>
          <p className="post-date">
            {new Date(post.createdAt).toISOString().split("T")[0]}
          </p>
        </div>
        {post.userId !== userId && !post.isRepost && (
          <RepostButton
            userId={userId}
            authorId={post.userId}
            originalPostId={post.postId}
          />
        )}
      </div>
    </div>
  );
});

export default Posts;
