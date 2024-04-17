#pragma once

#include <vector>
#include <limits>
#include <algorithm>
#include <array>

#include "../math/point.hpp"
#include "../math/size.hpp"
#include "../math/rect.hpp"

namespace FaceLandmarking::Mask
{
	template<size_t Nodes>
	class FaceMask
	{
	private:
		std::array<Math::Point<float>, Nodes> points;

	public:
		Math::Point<float>& operator[](int n)
		{
			return points[n];
		}

		const Math::Point<float>& operator[](int n) const
		{
			return points[n];
		}

		auto begin() const
		{
			return points.begin();
		}

		auto begin()
		{
			return points.begin();
		}

		auto end() const
		{
			return points.end();
		}

		auto end()
		{
			return points.end();
		}

		Math::Point<float> faceCenter() const
		{
			float x = 0;
			float y = 0;

			for (const auto& point : *this)
			{
				x += point.x;
				y += point.y;
			}

			return Math::Point<float>{x / Nodes, y / Nodes};
		}

		Math::Size<float> faceSize() const
		{
			float
				minX = std::numeric_limits<float>::max(),
				maxX = std::numeric_limits<float>::min(),
				minY = std::numeric_limits<float>::max(),
				maxY = std::numeric_limits<float>::min();

			for (const auto& point : *this)
			{
				minX = std::min(minX, point.x);
				maxX = std::max(maxX, point.x);
				minY = std::min(minY, point.y);
				maxY = std::max(maxY, point.y);
			}

			return Math::Size<float>(
				maxX - minX, 
				maxY - minY);
		}

		Math::Rect<float> faceRect() const
		{
			return Math::Rect<float>(
				faceCenter(), 
				faceSize());
		}
	};
}